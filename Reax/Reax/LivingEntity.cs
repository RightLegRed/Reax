﻿using System;
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
    class LivingEntity {

        public Vector2 position;
        public String playerName;
        public float rotation;
        public float speed = 2;
        public float scale = 1.0f;
        public float health = 100;
        public float maxHealth = 100;
        public int drawX = 32;
        public int drawY = 32;
        public int drawPX = 30;
        public int drawPY = 0;
        public Boolean alive = true;
        public string sFileName = "spritesheet";
        public BoundingBox boundingBox;
        public Game1 game;

        public Texture2D spriteIndex;

        public LivingEntity() { }

        public LivingEntity(Vector2 position, Game1 game) {
            this.position = position;
            this.game = game;
        }

        public virtual void loadContent(ContentManager content) {
            spriteIndex = content.Load<Texture2D>("Sprites\\" + sFileName);
        }

        public virtual void Update() {
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            Rectangle size = new Rectangle(0, 0, 32, 32);
            Texture2D newCropped = game.spriteLibrary.Crop(spriteIndex, new Rectangle(drawPX, drawPY, drawX, drawY));
            Vector2 center = new Vector2(newCropped.Width / 2, newCropped.Height / 2);
            spriteBatch.Draw(newCropped, position, size, Color.White, MathHelper.ToRadians(rotation), center, scale, SpriteEffects.None, 0);
        }

        public void pushTo(float pix, float dir) {
            float newX = (float)Math.Cos(MathHelper.ToRadians(dir));
            float newY = (float)Math.Sin(MathHelper.ToRadians(dir));
            position.X += pix * (float)newX;
            position.Y += pix * (float)newY;
        }

        public void Damage(int amount) {
            health -= amount;
            if (health < 0) {
                alive = false;
            }
        }

        public void Damage(float amount) {
            health -= amount;
            if (health < 0) {
                alive = false;
            }
        }

        public void Heal(float amount) {
            health += amount;
        }

        public void Heal(int amount) {
            health += amount;
        }
    }
}
