﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable  {
    void Damage();
    int Health { get; set; }
}
