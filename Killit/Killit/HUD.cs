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
    class HUD {

        Game1 game;
        Boolean enabled;
        int health;
        int stamina;
        Texture2D healthTexture;
        Texture2D healthbarTexture;
        Texture2D staminaTexture;
        Texture2D cursor;

        public HUD(Game1 game) {
            this.game = game;
        }

        public virtual void loadContent(ContentManager content, String sFileName) {
            healthTexture = content.Load<Texture2D>("Sprites\\" + sFileName);
            healthbarTexture = content.Load<Texture2D>("Sprites\\healthbar_out");
            staminaTexture = content.Load<Texture2D>("Sprites\\staminabar");
            cursor = content.Load<Texture2D>("Sprites\\cursor");
        }

        public virtual void Update() {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            Player player = (Player)game.getEntities().getByType(typeof(Player));
            Rectangle cursorRec = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 16, 16);
            Rectangle staminaRec = new Rectangle((int)player.position.X - 16, (int)player.position.Y - 24, (int)(0.32 * (int)player.stamina), 4);
            Rectangle healthRec = new Rectangle((int)player.position.X - 16, (int)player.position.Y - 28, (int)( (32/player.maxHealth) * (int) player.health), 4);
            Rectangle healthBarRec = new Rectangle((int)player.position.X - 16, (int)player.position.Y - 28, 32, 8);
            spriteBatch.DrawString(game.getSpriteFont(), player.playerName, new Vector2(healthRec.Location.X - (player.playerName.Length * 3 / 2), healthRec.Location.Y - 16), Color.White);
            spriteBatch.Draw(healthTexture, healthRec, Color.White);
            spriteBatch.Draw(staminaTexture, staminaRec, Color.White);
            spriteBatch.Draw(healthbarTexture, healthBarRec, Color.White);
            spriteBatch.Draw(cursor, cursorRec, Color.White);
        }
    }
}
