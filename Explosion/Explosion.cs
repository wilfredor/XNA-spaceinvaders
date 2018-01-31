using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Collections.Generic;

namespace SpaceInvaders
{
    class Explosion : DrawableGameComponent
    {
        
        Vector2 positionBullet = Vector2.Zero;
                
        SpriteBatch spriteBatch;
               
        List<Particle> listParticle;   

        public Explosion(ref SpaceInvaders game, Vector2 positionBullet) : base (game)
		{
            this.positionBullet = positionBullet;
            //should only ever be one player, all value defaults set in Initialize()
        }


        public override void Update(GameTime gameTime)
        {
            listParticle.ForEach(x => x.Move());

            listParticle.RemoveAll(x => x.delete);

            if (listParticle.Count.Equals(0))
            {
                Game.Components.Remove(this);
            }                     

            base.Update(gameTime);
        }        

        protected override void LoadContent()
        {
            base.LoadContent();

            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
        }

        public override void Initialize()
        {
            base.Initialize();
            Random rnd = new Random();

            listParticle = new List<Particle>() { };

            //Particles Explosion generator
            for (int i=0;i<=Constant.ExplosionParticlesCount; i++)
            {
                listParticle.Add(
                    new Particle(
                        Game, positionBullet,
                        new Vector2()
                        { 
                            X = rnd.Next(-1* Constant.ExplosionParticlesSpeedRange, Constant.ExplosionParticlesSpeedRange),
                            Y = rnd.Next(-1* Constant.ExplosionParticlesSpeedRange, Constant.ExplosionParticlesSpeedRange)
                        }
                    )

                );                
            }
            
        }

        public override void Draw(GameTime gameTime)
        {

            listParticle.ForEach(x => x.Rect.SetData(x.data));            

            base.Draw(gameTime);
            
            spriteBatch.Begin();
            //spriteBatch.Draw(bullet, position, Color.White);
            foreach (Particle particle in listParticle)
            {
                spriteBatch.Draw(particle.Rect, particle.position, Color.White);
            }


            spriteBatch.End();
        }

    }
}
