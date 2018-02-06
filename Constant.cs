using Microsoft.Xna.Framework;
using System.Text;

namespace SpaceInvaders
{
    public static class Constant
    {
        public const int LivesQuantity = 5;
        public const int ShootsQuantity = 15;
        public const int PackageQuantity = 5000;
        public const int LivePackageTime = 2000;
        public const string ShotsLabel = "Bullets";
        public const string LivesLabel = "Lives";
        public const string LevelLabel = "Level";
        public const string ScoreLabel = "SCORE";
        public const string GameOverLabel = "GAME OVER";
        public const string RootContentDirectory = "Content";

        //Particle
        public const int ParticleHeight = 20;
        public const int ParticleWidth = 20;
        public const int ExplosionSpeed = 5;
        public const int ExplosionParticlesCount = 50;
        public const int ExplosionParticlesSpeedRange = 4;

        //Paths
        public const string EnemiesPath = "enemies\\";
        public const string BulletsPath = "bullets\\";
        public const string ExplosionPath = "explosion\\";
        public const string MapsPath = "maps\\";
        public const string NavesPath = "naves\\";
        public const string ParticlesPath = "particles\\";
        public const string FontsPath = "fonts\\";


        //Main bar info
        public static StringBuilder InfoBar() {
            StringBuilder infoLabel = new StringBuilder();
            infoLabel.Append(Constant.ScoreLabel).Append(": ").Append(GameInfo.Score.ToString()).Append("   ");
            infoLabel.Append(Constant.LevelLabel).Append(": ").Append(GameInfo.Level.ToString()).Append("   ");
            infoLabel.Append(Constant.LivesLabel).Append(": ").Append(GameInfo.Lives.ToString()).Append("   ");
            infoLabel.Append(Constant.ShotsLabel).Append(": ").Append(GameInfo.Shots.ToString());
            return infoLabel;
        }
    }
}
