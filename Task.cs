using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace krohalev_1
{
    #region Interfaces 

    interface IActivitible
    {
        void Make(Player Player);
    }

    interface ICanFigth : IActivitible
    {
        void Fight(Player Player);
    }

    interface ICanCollect : IActivitible
    {
        void Collect(Player Player);
    }

    interface ICanGetOwn : IActivitible
    {
        void GetOwn(Player Player);
    }

    interface IConstruction : ICanGetOwn
    {
        int Owner { get; set; }
    }


    // у меня оч тупил и пропадал интернет поэтому я сдал только сейчас
    // я хотел бы реализовать в интрфейсы методы по умолчанию, но как оказалось это доступно только с 8.0, у меня 7.3,
    // Обновить из-за интернета и времени не смог
    interface IArmy : ICanFigth
    {
        Army Army { get; set; }
    }

    interface ITreasure : ICanCollect
    {
        Treasure Treasure { get; set; }
    }
    #endregion

    #region GameElementClasses 
    public class Dwelling : IConstruction
    {
        public int Owner { get; set; }

        public void GetOwn(Player player)
        {
            Owner = player.Id;
        }

        public void Make(Player player)
        {
            GetOwn(player);
        }
    }

    public class Mine : IConstruction, IArmy, ITreasure
    {
        public int Owner { get; set; }
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }

        public void GetOwn(Player player)
        {
            Owner = player.Id;
        }
        public void Collect(Player player)
        {
            player.Consume(Treasure);
        }
        public void Fight(Player player)
        {
            if (!player.CanBeat(this.Army))
            {
                player.Die();
            }
        }
        public void Make(Player player)
        {
            GetOwn(player);
            Collect(player);
            Fight(player);
        }
    }

    public class Creeps : IArmy, ITreasure
    {
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }
        public void Collect(Player player)
        {
            player.Consume(Treasure);
        }
        public void Fight(Player player)
        {
            if (!player.CanBeat(this.Army))
            {
                player.Die();
            }
        }
        public void Make(Player player)
        {
            Collect(player);
            Fight(player);
        }
    }

    public class Wolves : IArmy
    {
        public Army Army { get; set; }

        public void Fight(Player player)
        {
            if (!player.CanBeat(this.Army))
            {
                player.Die();
            }
        }
        public void Make(Player player)
        {
            Fight(player);
        }
    }

    public class ResourcePile : ITreasure
    {
        public Treasure Treasure { get; set; }

        public void Collect(Player player)
        {
            player.Consume(Treasure);
        }
        public void Make(Player player)
        {
            Collect(player);
        }
    }
    #endregion

}