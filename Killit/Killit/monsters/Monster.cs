using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reax;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Killit.monsters {
    class Monster : LivingEntity {

        public int hostile = 0;
        public LivingEntity target;

        public Monster(Vector2 position, Game1 game) 
            : base(position, game){
            speed = 2f; 
        }

        public override void Update() {
            base.Update();
            if (hostile == 1) {
                foreach (LivingEntity e in game.getEntities().itemsList) {
                    int distance = Distance2D(position.X, position.Y, e.position.X, e.position.Y);
                    if (e != this && distance > 75) {
                        target = e;
                    }


                    if (target != null && distance > 40) {
                        if (distance > 400) {
                            target = null;
                            return;
                        }
                        double angle = Math.Atan2(target.position.Y - this.position.Y, target.position.X - this.position.X) * 180 / Math.PI;
                        pushTo(speed, (float)angle);
                    }

                }
            }

        }

        public override void Draw(SpriteBatch spriteBatch) {
            base.Draw(spriteBatch);

        }

        public int Distance2D(float x1, float y1, float x2, float y2) {
            int result = 0;
            double part1 = Math.Pow((x2 - x1), 2);
            double part2 = Math.Pow((y2 - y1), 2);
            double underRadical = part1 + part2;
            result = (int)Math.Sqrt(underRadical);
            return result;
        }

    }
}
