using UnityEngine;
public interface IDamagable{
    public float Health {set; get;}
    public bool Targetable {set; get;}
    public void OnHit(float damage, Vector2 knockback);
    //no Knockback
    public void OnHit(float damage);

    public void onObjectDestoyed();
}