using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();
    private float[] attackradiusarry = new float[] {1f,0.8f,1.2f };//半径
    private void animationtrigger()
    {
        player.animationtrigger();
    }

    private void attacktrigger()
    {
        int currentcombo = player.anim.GetInteger("combocounter");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackcheck.position, player.attackcheckradius * attackradiusarry[currentcombo]);

        foreach(var hit in colliders)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy != null)
            {
                float attackdirx = Mathf.Sign(hit.transform.position.x - player.transform.position.x);
                enemy.damage(attackdirx);
                enemystat target =hit.GetComponent<enemystat>();
                player.Stat.Dodamage(target);
                ItemDataEquipment weaponData = Inventory.instance.GetEquipment(EquipmentType.Weapon);//获取装备

                if(weaponData != null)//如果不为空
                {
                    weaponData.Effect(target.transform);
                }
            }
                
        }//碰撞检测
    }
}
