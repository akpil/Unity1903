﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimHash
{
    public static readonly int Attack = Animator.StringToHash("IsAttack");
    public static readonly int Walk = Animator.StringToHash("IsWalk");
    public static readonly int Dead = Animator.StringToHash("IsDead");
}