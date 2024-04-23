using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BasicEnemy : Enemy
{
    private void Start()
    {
        Health = new(10, 10);
    }
}
