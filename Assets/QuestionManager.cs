using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public static bool[] questions = new bool[4];

    public static bool AllCorrect()
    {
        return questions[0] && questions[1] && questions[2] && questions[3];
    }
}
