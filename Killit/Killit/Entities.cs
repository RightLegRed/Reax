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
using Killit.monsters;
namespace Reax {
    class Entities {
        
        public List<LivingEntity> itemsList = new List<LivingEntity>();
        Game1 game;

        public Entities(Game1 game) {
            this.game = game;
        }

        public void Initalize() {
            addItem(new Player(new Vector2(50, 50), game));
            addItem(new Monster(new Vector2(50, 40), game));
            addItem(new Monster(new Vector2(50, 70), game));
            addItem(new Monster(new Vector2(50, 130), game));
            
        }

        public void removeItem(LivingEntity item) {
            itemsList.Remove(item);
        }

        public void addItem(LivingEntity item) {
            itemsList.Add(item);
        }

        public LivingEntity getByType(Type type) {
            foreach (LivingEntity i in itemsList) {
                if (i.GetType() == type) {
                    return i;
                }
            }
            return null;
        }
    }
}
