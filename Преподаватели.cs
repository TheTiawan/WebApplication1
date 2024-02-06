using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Преподаватели
{
    public int ТабельныйНомер { get; set; }

    public string Фамилия { get; set; } = null!;

    public string? Должность { get; set; }

    public string? Кафедра { get; set; }

    public int? Стаж { get; set; }

    public virtual ICollection<УчебнаяНагрузка> УчебнаяНагрузкаs { get; set; } = new List<УчебнаяНагрузка>();
}
