using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace JetPac.GameEngine
{
    /// <summary>Имена всех звуковых эффектов</summary>
    public enum SoundNames
    {
        ItemPickUp = 0,
        PulseShot = 1,
    }

    public static class SoundEngine
    {
        public static List<SoundEffect> SoundList = new List<SoundEffect>();

        //Инициализация загрузка всех эфектов
        public static void SoundInit(ContentManager Content)
        {
            SoundList.Add(Content.Load<SoundEffect>("ItemPickUp"));
            SoundList.Add(Content.Load<SoundEffect>("PulseShot"));
            
        }

        public static SoundEffect GetEffect(SoundNames s)
        {
            return SoundList[(int)s];
        }
    }

}
