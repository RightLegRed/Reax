using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;

namespace Reax {
    class Entities {

        public List<LivingEntity> livingList = new List<LivingEntity>();
        private List<Monster> monsterList = new List<Monster>();

        private Reax game;
        public Entities(Reax game) {
            this.game = game;
        }
        public void Initialize() {
            addLivingEntity(new Monster(new Microsoft.Xna.Framework.Vector2(0, 0), 5f, "advntur", game));
            addLivingEntity(new Player(new Microsoft.Xna.Framework.Vector2(20, 20), 4f, "advntur", game));
        }

        public void addLivingEntity(LivingEntity entity) {
            if(entity.GetType() == typeof(Monster)){
                addLivingEntity((Monster)entity);
                return;
            }
            livingList.Add(entity);
        }

        public void addLivingEntity(Monster entity) {
            livingList.Add(entity);
            monsterList.Add(entity);
        }

        public void removeLivingEntity(LivingEntity entity) {
            if (entity.GetType() == typeof(Monster)) {
                removeLivingEntity((Monster)entity);
                return;
            }
            livingList.Remove(entity);
        }

        public void removeLivingEntity(Monster entity) {
            livingList.Remove(entity);
            monsterList.Remove(entity);
        }
        

        public List<LivingEntity> getEntityList() {
            return livingList.ToList();
        }
    }
}
