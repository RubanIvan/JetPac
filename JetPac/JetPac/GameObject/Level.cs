using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JetPac.GameObject
{
    //структура храник координаты и размер конкретной полочки
    struct RackPoint
    {
        public int x;
        public int y;
        public int length;

        public RackPoint(int X, int Y, int len)
        {
            this.x = X;
            this.y = Y;
            this.length = len;
        }
    }

    //список всех полочек и координаты космодрома для уровня
    class Level
    {
        /// <summary>координаты и длинна полочек</summary>
        public List<RackPoint> Racks;

        /// <summary>Координаты ракеты</summary>
        public Point Kosmodrom;

        /// <summary>Необходима ли сборка ракеты</summary>
        public bool isAssemblyRequired;

        /// <summary>Какая ракета на этом уровне</summary>
        public RocketType RocketType;

        //Тип врагов в игре
        public Type EnemyType;

        //Максимальное кол-во противников на уровне
        public int MaxEnemy;
    }

    //список всех уровней с их координатами
    static class GameLevels
    {
        public static List<Level> Level = new List<Level>();

        static GameLevels()
        {
            #region первая ракета
            Level l1 = new Level();
            l1.Racks = new List<RackPoint>();
            l1.Racks.Add(new RackPoint(85, 235, 10));
            l1.Racks.Add(new RackPoint(575, 140, 10));
            l1.Racks.Add(new RackPoint(315, 375, 6));
            l1.Kosmodrom = new Point(480, 584);
            l1.isAssemblyRequired = true;
            l1.RocketType=RocketType.RocketU1;
            l1.EnemyType = typeof (EnemyMeteor);
            l1.MaxEnemy = 8;
            Level.Add(l1);

            l1 = new Level();
            l1.Racks = new List<RackPoint>();
            l1.Racks.Add(new RackPoint(85, 145, 10));
            l1.Racks.Add(new RackPoint(280, 270, 10));
            l1.Racks.Add(new RackPoint(590, 400, 6));
            l1.Kosmodrom = new Point(480, 584);
            l1.isAssemblyRequired = false;
            l1.RocketType = RocketType.RocketU1;
            Level.Add(l1);

            l1 = new Level();
            l1.Racks = new List<RackPoint>();
            l1.Racks.Add(new RackPoint(115, 140, 10));
            l1.Racks.Add(new RackPoint(575, 140, 10));
            l1.Racks.Add(new RackPoint(350, 340, 6));
            l1.Kosmodrom = new Point(480, 584);
            l1.isAssemblyRequired = false;
            l1.RocketType = RocketType.RocketU1;
            Level.Add(l1);
            #endregion
            
            #region вторая ракета
            l1 = new Level();
            l1.Racks = new List<RackPoint>();
            l1.Racks.Add(new RackPoint(100, 280, 10));
            l1.Racks.Add(new RackPoint(565, 400, 10));
            l1.Racks.Add(new RackPoint(350, 140, 6));
            l1.Kosmodrom = new Point(480, 584);
            l1.isAssemblyRequired = true;
            l1.RocketType = RocketType.RocketU2;
            Level.Add(l1);

            l1 = new Level();
            l1.Racks = new List<RackPoint>();
            l1.Racks.Add(new RackPoint(130, 140, 10));
            l1.Racks.Add(new RackPoint(130, 400, 10));
            l1.Racks.Add(new RackPoint(585, 250, 6));
            l1.Kosmodrom = new Point(480, 584);
            l1.isAssemblyRequired = false;
            l1.RocketType = RocketType.RocketU2;
            Level.Add(l1);

            l1 = new Level();
            l1.Racks = new List<RackPoint>();
            l1.Racks.Add(new RackPoint(285, 410, 10));
            l1.Racks.Add(new RackPoint(600, 150, 10));
            l1.Racks.Add(new RackPoint(500, 300, 6));
            l1.Kosmodrom = new Point(170, 584);
            l1.isAssemblyRequired = false;
            l1.RocketType = RocketType.RocketU2;
            Level.Add(l1);
            #endregion

            #region третья ракета
            l1 = new Level();
            l1.Racks = new List<RackPoint>();
            l1.Racks.Add(new RackPoint(485, 150, 6));
            l1.Racks.Add(new RackPoint(375, 265, 20));
            l1.Racks.Add(new RackPoint(300, 400, 30));
            l1.Kosmodrom = new Point(170, 584);
            l1.isAssemblyRequired = true;
            l1.RocketType = RocketType.RocketU3;
            Level.Add(l1);

            l1 = new Level();
            l1.Racks = new List<RackPoint>();
            l1.Racks.Add(new RackPoint(485, 150, 6));
            l1.Racks.Add(new RackPoint(375, 265, 10));
            l1.Racks.Add(new RackPoint(300, 400, 10));
            l1.Kosmodrom = new Point(170, 584);
            l1.isAssemblyRequired = false;
            l1.RocketType = RocketType.RocketU3;
            Level.Add(l1);

            l1 = new Level();
            l1.Racks = new List<RackPoint>();
            l1.Racks.Add(new RackPoint(560, 145, 10));
            l1.Racks.Add(new RackPoint(360, 320, 10));
            l1.Racks.Add(new RackPoint(50, 430, 6));
            l1.Kosmodrom = new Point(170, 584);
            l1.isAssemblyRequired = false;
            l1.RocketType = RocketType.RocketU3;
            Level.Add(l1);
            #endregion

        }
    }
}
