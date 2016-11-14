﻿namespace NechritoRiven.Event.OrbwalkingModes
{
    #region

    using Core;
    using EloBuddy;
    using EloBuddy.SDK;

    #endregion

    internal class ComboMode : NechritoRiven.Core.Core
    {
        #region Public Methods and Operators

        private static bool InWRange(GameObject target) => (Player.HasBuff("RivenFengShuiEngine") && target != null) ? 330 >= Player.Distance(target.Position) : 265 >= Player.Distance(target.Position);

        public static void Combo()
        {
            var targetAquireRange = Spells.R.IsReady() ? Player.AttackRange + 390 : Player.AttackRange + 370;
            var target = TargetSelector.GetTarget(250 + Player.AttackRange + 70, DamageType.Physical);
            //var target = TargetSelector.GetTarget(targetAquireRange, DamageType.Physical, Player.Position);

            if (target == null || !target.IsValidTarget() || target.Type != Player.Type) return;

            if (Spells.R.IsReady() && Spells.R.Name == IsSecondR)
            {
                var pred = Spells.R.GetPrediction(target);//, true, collisionable: new[] { CollisionableObjects.YasuoWall });

                if (pred.HitChance != EloBuddy.SDK.Enumerations.HitChance.High || target.HasBuff(BackgroundData.InvulnerableList.ToString()))// || Player.IsWindingUp)
                {
                    return;
                }

                if ((!MenuConfig.OverKillCheck && Qstack > 1)
                    || MenuConfig.OverKillCheck 
                    && (target.HealthPercent <= 40 
                    && !Spells.Q.IsReady() && Qstack == 1
                    || target.Distance(Player) >= Player.AttackRange + 310))
                {
                    Spells.R.Cast(pred.UnitPosition);
                }
            }

            #region Q3 Wall

            if (Qstack == 3
                    && target.Distance(Player) >= Player.AttackRange
                    && target.Distance(Player) <= 650
                    && MenuConfig.Q3Wall
                    && Spells.E.IsReady())
            {
                var wallPoint = FleeLogic.GetFirstWallPoint(Player.Position, Player.Position.Extend(target.Position, 650).To3D());//TODO: Fix this...

                Player.GetPath(wallPoint);

                if (!Spells.E.IsReady() || wallPoint.Distance(Player.Position) > Spells.E.Range || !wallPoint.IsValid())
                {
                    return;
                }
                Chat.Print("I casted E 1");
                Spells.E.Cast(wallPoint);

                if (Spells.R.IsReady() && Spells.R.Name == IsFirstR)
                {
                    Spells.R.Cast(target);
                }

                EloBuddy.SDK.Core.DelayAction(() => Spells.Q.Cast(wallPoint), 190);
                
                if (wallPoint.Distance(Player.Position) <= 100)
                {
                    Spells.Q.Cast(wallPoint);
                }
            } 
            #endregion

            if (Spells.E.IsReady())
            {
                Chat.Print("I casted E toward " + target.Name);
                Player.Spellbook.CastSpell(SpellSlot.E, target);
               // Spells.E.Cast(target);

                if (MenuConfig.AlwaysR && Spells.R.IsReady() && Spells.R.Name == IsFirstR)
                {
                    Spells.R.Cast(target);
                }
                else
                {
                    EloBuddy.SDK.Core.DelayAction(Usables.CastHydra, 10);
                }
            }

            if (!Spells.W.IsReady() || !BackgroundData.InRange(target))
            {
                return;
            }

            if (MenuConfig.Doublecast && Spells.Q.IsReady() && Qstack != 2)
            {
                BackgroundData.CastW(target);
                BackgroundData.DoubleCastQ(target);
            }
            else
            {
                BackgroundData.CastW(target);
            }
        }

        #endregion
    }
}