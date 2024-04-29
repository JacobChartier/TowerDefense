using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LaserTower : Tower
{
    public LineRenderer lineRenderer { get; private set; }

    protected override void Load()
    {
        base.Load();
        GetComponentInChildren<SpriteRenderer>(true).color = new(0.1886792f, 0.1886792f, 0.1886792f, 1);

        lineRenderer = transform.AddComponent<LineRenderer>();

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.05f;

        lineRenderer.material = Resources.Load<Material>("Materials/laser_beam");

        lineRenderer.startColor = new(1.0f, 0.0f, 1.0f, 1.0f);
        lineRenderer.endColor = new(1.0f, 0.0f, 1.0f, 1.0f);

        lineRenderer.SetPosition(0, transform.position);

        lineRenderer.enabled = false;
    }

    public override void Attack()
    {
        if (Target != null && CanAttack)
            StartCoroutine(PerformAttack());

        if (Target != null)
            lineRenderer.SetPosition(1, Target.transform.position);
    }

    private IEnumerator PerformAttack()
    {
        Debug.Log($"Attacking <b>{Target}</b>");
        Target.GetComponent<Enemy>().Health.Current--;
        Target.transform.localScale = new Vector2(Target.transform.localScale.x * 0.9f, Target.transform.localScale.x * 0.9f);
        CanAttack = false;

        lineRenderer.SetPosition(1, Target.transform.position);
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.2f);
        lineRenderer.enabled = false;
        yield return new WaitForSeconds(1.0f);

        CanAttack = true;
    }
}
