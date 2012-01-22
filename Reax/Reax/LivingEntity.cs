using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Reax {
    class LivingEntity {

        public Vector2 position { get; set; }
        protected Texture2D currentTexture;
        protected Body body;
        protected float speed = 4f;
        protected String name;
        protected Reax game;
        protected World world;

        public LivingEntity(Vector2 position, float speed, String name, Reax game) {
            this.position = position;
            this.speed = speed;
            this.name = name;
            this.world = game.getWorld();
            body = BodyFactory.CreateRectangle(world, 5, 5, 5);
            body.BodyType = BodyType.Dynamic;
            body.Mass = 1;
            body.Enabled = true;
        }

        public void pushTo(float pix, float dir) {
            float newX = (float)Math.Cos(MathHelper.ToRadians(dir));
            float newY = (float)Math.Sin(MathHelper.ToRadians(dir));
            float p1 = body.Position.X + pix * (float)newX;
            float p2 = body.Position.Y + pix * (float)newY;
            body.Position = new Vector2(p1, p2);
        }

        public virtual void Update() {
            this.position = body.Position;
        }

        public virtual void Draw(SpriteBatch batch) {
            Rectangle rec = new Rectangle(0, 0, 32, 32);
            batch.Draw(currentTexture, position, Color.White);
        }

        public virtual void loadContent(ContentManager content) {
            currentTexture = content.Load<Texture2D>("resources\\sprites\\" + name);
            Fixture fixture = FixtureFactory.AttachRectangle(32, 32, 2f, Vector2.Zero, body);
            fixture.OnCollision += onCollide;

        }

        public virtual bool onCollide(Fixture f1, Fixture f2, Contact contact) {
            Console.WriteLine("Hit");
            return true;
        }

    }
}
