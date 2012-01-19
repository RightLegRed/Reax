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
    class Projectiles {

        public List<Projectile> itemsList = new List<Projectile>();
        Game1 game;

        public Projectiles(Game1 game) {
            this.game = game;
        }

        public void removeItem(Projectile item) {
            itemsList.Remove(item);
        }

        public void addItem(Projectile item) {
            itemsList.Add(item);
        }

        public Projectile getByName(String type) {
            foreach (Projectile i in itemsList) {
                if (i.getProjectileName() == type) {
                    return i;
                }
            }
            return null;
        }
    }
}
