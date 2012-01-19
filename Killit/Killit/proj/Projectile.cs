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
    class Projectile {

        // Game Related
        private float speed;
        private float direction;
        private int damage;
        private LivingEntity shooter;
        private string projectileName;
        private double creationTime;
        public Game1 game;

        // Position Related
        private Vector2 originPosition;
        private Vector2 position;
        private float scale = 1.0f;

        // Texture
        Texture2D texture;
        
        public Projectile(float speed, float direction, int damage, LivingEntity shooter, Vector2 originPosition, double creationTime, string projectileName, Game1 game) {
            this.speed = speed;
            this.direction = direction;
            this.damage = damage;
            this.shooter = shooter;
            this.position = originPosition;
            this.projectileName = projectileName;
            this.creationTime = creationTime;
            this.game = game;
        }

        public virtual void Update() {
            pushTo(speed, direction);
            checkHit();
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            Rectangle size = new Rectangle(0, 0, 8, 8);
            Vector2 center = new Vector2(texture.Width / 2, texture.Height / 2);
            spriteBatch.Draw(texture, position, Color.Red);
        }

        public virtual void loadContent(ContentManager content) {
            texture = content.Load<Texture2D>("sprites\\" + projectileName);
        }

        public void pushTo(float pix, float dir) {
            float newX = (float)Math.Cos(MathHelper.ToRadians(dir));
            float newY = (float)Math.Sin(MathHelper.ToRadians(dir));
            position.X += pix * (float)newX;
            position.Y += pix * (float)newY;
        }

        public String getProjectileName() {
            return projectileName;
        }

        public double getCreationTime() {
            return creationTime;
        }

        public void checkHit(){
            Vector3[] boundaryPoints = new Vector3[2];
            boundaryPoints[0] = new Vector3(position.X, position.Y, 0);
            boundaryPoints[1] = new Vector3(position.X + 16, position.Y + 16, 0);
            BoundingBox.CreateFromPoints(boundaryPoints);
            foreach (LivingEntity e in game.getEntities().itemsList) {
                if(shooter != e && e.getBoundingBox().Intersects(BoundingBox.CreateFromPoints(boundaryPoints))){
                    e.Damage(1);
                }
            }
        }
    }
}
