using Terraria.ModLoader;
using Terraria;
using System;
using Microsoft.Xna.Framework;
namespace FallenStarFun{
	class FallenStarFun:Mod{}
	public class FallenStarRandomizer:GlobalProjectile{
		public override void SetDefaults(Projectile projectile){
			if(projectile.type==12){
				projectile.type=mod.ProjectileType("NewFallenStar");
				projectile.SetDefaults(projectile.type);
			}
		}
	}
	public class NewFallenStar:ModProjectile{
		public int item=1;
		public override string Texture{
			get{
				ModItem i=ItemLoader.GetItem(item);
				return i!=null?i.Texture:"Terraria/Item_"+item;
			}
		}
		public override void SetDefaults(){
			item=GetItem();
			ModItem i=ItemLoader.GetItem(item);
			if(i==null){
				Item I=new Item();
				I.type=item;
				I.SetDefaults1(I.type);
				I.SetDefaults2(I.type);
				I.SetDefaults3(I.type);
				I.SetDefaults4(I.type);
				projectile.width=I.width;
				projectile.height=I.height;
			}
			else{
				projectile.width=i.item.width;
				projectile.height=i.item.height;
			}
			//projectile.maxPenetrate=-1;
			projectile.aiStyle=5;
			projectile.friendly=true;
			projectile.penetrate=-1;
			projectile.alpha=50;
			projectile.light=1f;
		}
		public override bool OnTileCollide(Vector2 oldVelocity){
			Item.NewItem((int)projectile.position.X,(int)projectile.position.Y,0,0,item);
			return true;
		}
		public virtual void OnHitNPC(NPC target,int damage,float knockback,bool crit){
			Item.NewItem((int)projectile.position.X,(int)projectile.position.Y,0,0,item);
		}
		public virtual int GetItem(){return Main.rand.Next(ItemLoader.ItemCount);}
	}
}
