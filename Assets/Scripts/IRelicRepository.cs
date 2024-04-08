using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRelicRepository
{
    IRelicData GetRelicById(string id);
    IEnumerable<IRelicData> GetAllRelics();

    IEnumerable<IRelicData> GetRandomUniqueRelics(int count);
}