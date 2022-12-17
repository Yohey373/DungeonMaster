public class CharacterParameterBase
{
    protected float HitPoint;
    protected float maxHitPoint;
    protected float AttackPoint;

    public float GetAttackPoint {

        get { return AttackPoint; }
    }

    public float GetHitPoint
    {

        get { return HitPoint; }
    }

/*    public CharacterParameterBase(float hitPoint, float attackPoint)
    {
        this.HitPoint = hitPoint;
        this.maxHitPoint = this.HitPoint;
        this.AttackPoint = attackPoint;
    }
*/

    public void Damage(float damagePoint)
    {
        this.HitPoint -= damagePoint;
        if(this.HitPoint < 0)
        {
            this.HitPoint = 0;
        }
    }

    public void Heal(float healPoint)
    {
        this.HitPoint += healPoint;
        if (this.HitPoint > this.maxHitPoint)
        {
            this.HitPoint = this.maxHitPoint;
        }
    }

    public bool isDead() {

        return this.HitPoint <= 0;
    }

}
