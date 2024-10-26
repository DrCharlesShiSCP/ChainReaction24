
using UnityEngine;
public class Bomb : MonoBehaviour
{
    public float explosionRadius = 5f;      // 爆炸的范围
    public float initialExplosionDelay = 2f; // 初始炸弹的爆炸延迟
    public float chainExplosionDelay = 1f;   // 被引爆的炸弹的爆炸延迟
    public bool hasExploded = false;

    void Start()
    {
        // 开始时，延迟一定时间引爆初始炸弹
        Invoke("Explode", initialExplosionDelay);
    }

    public void TriggerExplosion()
    {
        if (!hasExploded)
        {
            // 被引爆时，延迟一定时间爆炸
            Invoke("Explode", chainExplosionDelay);
        }
    }

    void Explode()
    {
        if (hasExploded) return;

        hasExploded = true;

        // 添加爆炸效果（例如，粒子特效，声音等）
        Debug.Log("Bomb exploded at " + transform.position);

        // 找到所有在爆炸范围内的物体
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Bomb bomb = nearbyObject.GetComponent<Bomb>();
            if (bomb != null && bomb != this && !bomb.hasExploded)
            {
                // 引爆范围内的其他炸弹（延迟爆炸）
                bomb.TriggerExplosion();
            }
        }

        // 你可以在这里销毁炸弹对象，或者增加一些其他的效果
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        // 在编辑器中可视化爆炸范围
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}