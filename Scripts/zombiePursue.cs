using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class zombiePursue : Kinematic
    {
        Pursue myMoveType;
        LookWhereGoing myRotateType;
        public ThirdPersonCharacter character { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            myMoveType = new Pursue();
            myMoveType.character = this;
            myMoveType.target = myTarget;

            myRotateType = new LookWhereGoing();
            myRotateType.character = this;
            myRotateType.target = myTarget;
            character = GetComponent<ThirdPersonCharacter>();
        }

        // Update is called once per frame
        protected override void Update()
        {
            steeringUpdate = new SteeringOutput();
            steeringUpdate.linear = myMoveType.getSteering().linear;
            character.Move(Vector3.zero, false, false);
            steeringUpdate.angular = myRotateType.getSteering().angular;
            base.Update();
        }
    }
}