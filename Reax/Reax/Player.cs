using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework.Input;

namespace Reax {
    class Player : LivingEntity {

        public Player(Vector2 position, float speed, String name, Reax game)
            : base(position, speed, name, game) {

        }

        public override void Update() {
            base.Update();
            KeyboardState keyState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
            float altSpeed = speed;
            if(keyState.IsKeyDown(Keys.S)){
                pushTo(altSpeed, 90);
            }
            if (keyState.IsKeyDown(Keys.W)) {
                pushTo(altSpeed, -90);
            }
            if (keyState.IsKeyDown(Keys.A)) {
                pushTo(altSpeed, 180);
            }
            if (keyState.IsKeyDown(Keys.D)) {
                pushTo(altSpeed, 360);
            }
            
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch batch) {
            base.Draw(batch);
        
        }

        public override void loadContent(Microsoft.Xna.Framework.Content.ContentManager content) {
            base.loadContent(content);
        
        }
    }
}
