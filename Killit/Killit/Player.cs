using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Reax {
    class Player : LivingEntity{

        KeyboardState keyboard;
        KeyboardState previousKeyboard;
        MouseState mouse;
        long previousTime = 0;
        long currentTime = 0;
        public float stamina = 100;
        

        public Player(Vector2 position, Game1 game)
            : base(position, game) {
                this.position = position;
                this.health = 100;
                playerName = "Archelaus";
        }

        public override void Update() {
            int direction = 0;
            keyboard = Keyboard.GetState();
            mouse = Mouse.GetState();
            currentTime = System.Environment.TickCount;
            // Movements
            float moveSpeed = speed;
            if (keyboard.IsKeyDown(Keys.LeftShift) && stamina > 0) {
                stamina -= 1f;
                moveSpeed += 1.5f;
            }
            if (keyboard.IsKeyDown(Keys.W)) {
                pushTo(-moveSpeed, 90f);
                drawPX = 0;
                drawPY = 96;
                direction = 1;
            }
            if (keyboard.IsKeyDown(Keys.D)) {
                pushTo(moveSpeed, 0f);
                drawPX = 60;
                drawPY = 64;
                direction = 2;
            }
            if (keyboard.IsKeyDown(Keys.A)) {
                pushTo(-moveSpeed, 0f);
                drawPX = 60;
                drawPY = 32;
                direction = 3;
            }
            if (keyboard.IsKeyDown(Keys.S)) {
                pushTo(moveSpeed, 90f);
                drawPX = 0;
                drawPY = 0;
                direction = 4;
            }
            if (keyboard.IsKeyDown(Keys.Q)) {
                Damage(1);
            }
            if (!(stamina + 0.1f > 100) && !keyboard.IsKeyDown(Keys.LeftShift)) {
                stamina += 0.5f;
            }
            if (mouse.LeftButton == ButtonState.Pressed) {
                Projectile p;
                double angle = Math.Atan2(mouse.Y - this.position.Y, mouse.X - this.position.X) * 180 / Math.PI;
                game.projectiles.addItem(p = new Projectile(2f, (float)angle, 10, this, position, game.getGameTime().TotalGameTime.TotalSeconds, "advntur", game));
                p.loadContent(game.Content);
            }

            // Movement End
            previousTime = System.Environment.TickCount;
            previousKeyboard = keyboard;

            base.Update();
        }

        public override void loadContent(ContentManager content) {
            base.loadContent(content);

        }


    }
}
