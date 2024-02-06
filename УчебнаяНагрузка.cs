using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class УчебнаяНагрузка
{
    public int Преподаватель { get; set; }

    public int Дисциплина { get; set; }

    public int Группа { get; set; }

    public int Семестр { get; set; }

    public int КоличествоЧасов { get; set; }

    public virtual Дисциплины ДисциплинаNavigation { get; set; } = null!;

    public virtual Преподаватели ПреподавательNavigation { get; set; } = null!;
}
