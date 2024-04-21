using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRelicRepository
{
    IRelicData GetRelicById(int id);
    IEnumerable<IRelicData> GetAllRelics();

    IEnumerable<IRelicData> GetRandomUniqueRelics(int count);
}