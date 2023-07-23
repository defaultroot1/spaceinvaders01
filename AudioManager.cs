using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceinvaders01
{
    public static class AudioManager
    {
        private static SoundEffect _playerLaserFX;
        private static SoundEffect _alienLaserFX;
        private static SoundEffect _alienHitFX;
        private static SoundEffect _playerHitFX;

        public static void Init()
        {
            _playerLaserFX = SpaceInvaders.contentManager.Load<SoundEffect>("Audio/laser2");
            _alienLaserFX = SpaceInvaders.contentManager.Load<SoundEffect>("Audio/laser3");
            _alienHitFX = SpaceInvaders.contentManager.Load<SoundEffect>("Audio/explosion1");
            _playerHitFX = SpaceInvaders.contentManager.Load<SoundEffect>("Audio/explosion2");
        }
        public static void playPlayerLaserFX()
        {
            _playerLaserFX.Play();
        }

        public static void playAlienLaserFX()
        {
            _alienLaserFX.Play();
        }

        public static void playAlienHitFX()
        {
            _alienHitFX.Play();
        }

        public static void playPlayerHitFX()
        {
            _playerHitFX.Play();
        }


    }
}
