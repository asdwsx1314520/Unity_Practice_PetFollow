using UnityEngine;

namespace KID
{
    public class Player : MonoBehaviour
    {
        [Header("移動速度"), Range(0, 1000)]
        public float speed = 1.5f;
        [Header("旋轉速度"), Range(0, 1000)]
        public float turn = 1.5f;

        private Rigidbody rig;

        public Transform pet;
        public Transform test;

        private void Start()
        {
            rig = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Turn();
        }

        private void FixedUpdate()
        {
            Move();

            PetTurn();
        }

        private void Move()
        {
            float v = Input.GetAxisRaw("Vertical");
            rig.AddForce(transform.forward * v * speed * Time.fixedDeltaTime);
        }

        private void Turn()
        {
            float h = Input.GetAxisRaw("Horizontal");
            transform.Rotate(0, h * Time.deltaTime * turn, 0);
        }

        /// <summary>
        /// 寵物更隨
        /// </summary>
        private void PetTurn()
        {
            Vector3 petPosition = pet.position;
            Vector3 plaPosition = test.position;

            pet.position = Vector3.Lerp(petPosition, plaPosition, 0.5f);
            pet.LookAt(plaPosition);
        }
    }
}

