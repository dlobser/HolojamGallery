using UnityEngine;
using System.Collections;

namespace AssemblyCSharp
{
    public class BatonController : MonoBehaviour
    {

        public Vector3 direction = Vector3.zero;
        Vector3 lastFrameLocation = Vector3.zero;

//        public MasterStream stream;
        public string label;

        void Start()
        {

        }

        private const int A = 2048;
        private const int B = 1024;

        void Update()
        {
//            if (stream) this.PositionController();
            //this.HandleButtons();
            Vector3 v = this.transform.position;
            direction = v - lastFrameLocation;
            lastFrameLocation = v;
        }

        void PositionController()
        {
//            Vector3 pos = stream.getRigidBodyPosData(label);
//            Quaternion rot = stream.getRigidBodyRotData(label);
//            this.transform.localPosition = pos;
//            this.transform.localRotation = rot;
        }

        void HandleButtons()
        {
//            int button_bits = stream.getButtonStatus(label);

//            if ((button_bits & A) > 0)
//            {
//                //A PRESSED
//            }
//            else
//            {
//                //A RELEASED
//            }
//            if ((button_bits & B) > 0)
//            {
//                //B PRESSED
//            }
//            else
//            {
//                //B RELEASED
//            }
        }
    }
}