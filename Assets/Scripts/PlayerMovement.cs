using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController = null; //Editorden CharacterController componentini surukleyebilmek icin SerializeField kullaniyoruz. Ayni GameObject altinda olduklari icin Start ya da Awake icinde GetComponent ile de tutulabilir.

    [SerializeField] private float _moveSpeed = 10f;//Editorden oyun sirasinda ayarlamalar ve debug yapmak adina hareket hizi, ziplama yuksekligi ve yer cekimi gibi degiskenlerde SerializeField ile tanimlanmistir. Dilenirse degerler kesinlesince SerializeField kaldirilabilir.
    [SerializeField] private float _jumpHeight = 3f;
    [SerializeField] private float _gravity = -9.81f;

    [SerializeField] private Transform _groundCheck = null;//Karakterin yere degip degmedigini kontrol edecek olan GameObject'in transformu
    [SerializeField] private float _groundDistance = 0.1f;

    [SerializeField] private LayerMask _layer;//Yer tespiti yapilirken kontrol edilecek Ground GameObject'in layer degiskeni

    [SerializeField] private Joystick _joystick = null;

    private Vector3 _velocity = Vector3.zero;//Ziplama ve dusus sirasinda elde edilen hiz

    private bool _isGrounded = true;//Yere degip degmedigimizi tutan bool degeri

    private void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _layer);//Verdigimiz pozisyonda verdigimiz yaricap kadar biz kure icerisinde _isGrounded kontrolu yapiyoruz.

        if (_isGrounded && _velocity.y < 0)
            _velocity.y = -2f;

        //float x = Input.GetAxis("Horizontal");//Ileri-geri ve sag-sol hareketleri yapabilmek icin Inputlari aliyoruz.
        //float z = Input.GetAxis("Vertical");

        float x = _joystick.Horizontal;
        float z = _joystick.Vertical;

        Vector3 move = transform.right * x + transform.forward * z;//transform.right bize GameObject'in sag yonunu verdigi icin float x'ten gelecek pozitif ya da negatif deger karakterin saga ya da sola gitmesini belirleyecek (-sag = sol). Ayni durum float z'de ileri geri gitme icinde gecerli.

        _characterController.Move(move * Time.deltaTime *_moveSpeed);//ustte belirledigimiz Vector3 pozisyonuna karakterimizi hareket ettiriyoruz. Hareket etme isleminin zamana bagli olmasi gerektigi icin Time.deltaTime ve hiz degerimiz ile carpiyoruz.

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)//Space tusuna basinca zipladigimiz icin hem Input kontrolu hemde yere dusmus mu kontrolu yapiyoruz.
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);//Yukari yonlu gravitye ters guc veriyoruz.

        _velocity.y += _gravity * Time.deltaTime;//Surekli yer cekimi uygulayarak y pozisyonunu azaltiyoruz.

        _characterController.Move(_velocity * Time.deltaTime);//Gravity sonucu olusan hiz degerine gore pozisyon veriyoruz.
    }
}