using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;

namespace Reax {
    class Monster : LivingEntity {

        public Monster(Vector2 position, float speed, String name, Reax game)
            : base(position, speed, name, game) {

        }

        public override void Update() {
            base.Update();
            /**
            foreach(LivingEntity e in game.getEntities().livingList) {
                if(e == this){
                    return;
                }
                double dist = distance(e.position, this.position);
                if (dist > 45 && dist > 450) {
                    double angle = Math.Atan2(e.position.Y - this.position.Y, e.position.X - this.position.X) * 180 / Math.PI;
                }

            }
             **/



        }

        public double distance(Vector2 p, Vector2 q) {
            double dx = p.X - q.X;
            double dy = p.Y - q.Y;
            double dist = Math.Sqrt(dx * dx + dy * dy); 
            return dist;
        }
    }
}
