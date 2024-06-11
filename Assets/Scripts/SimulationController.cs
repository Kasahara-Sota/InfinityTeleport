using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimulationController : MonoBehaviour
{
    private Scene m_simulationScene;
    private PhysicsScene2D m_physicsScene;
    [SerializeField] Transform m_obstacleParent;

    [SerializeField] private LineRenderer m_line;
    [SerializeField] private int m_iMaxPhysicsFrame;

    #region É{Å[Éãä÷åW
    [SerializeField] private GameObject m_ballPrefab;
    [SerializeField] private Transform m_tfBallPos;
    [SerializeField] private Vector2 m_ballVelocity;
    #endregion

    void Start()
    {
        CreatePhysicsScene();
    }

    private void Update()
    {
        Simulation(m_ballPrefab, m_tfBallPos.position, m_ballVelocity);
        if (Input.GetButtonDown("Fire1"))
        {
            var ghost = Instantiate(m_ballPrefab, m_tfBallPos.position, Quaternion.identity);
        }
    }

    private void CreatePhysicsScene()
    {
        m_simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics2D));
        m_physicsScene = m_simulationScene.GetPhysicsScene2D();

        foreach (Transform tf in m_obstacleParent)
        {
            var ghost = Instantiate(tf.gameObject, tf.position, tf.rotation);
            ghost.GetComponent<Renderer>().enabled = false;
            SceneManager.MoveGameObjectToScene(ghost, m_simulationScene);
        }
    }

    private void Simulation(GameObject _ballPrefab, Vector3 _pos, Vector2 _velocity)
    {
        var ghost = Instantiate(_ballPrefab, _pos, Quaternion.identity);
        ghost.GetComponent<Renderer>().enabled = false;
        ghost.transform.position = _pos;
        Debug.Log(_pos);
        ghost.GetComponent<Rigidbody2D>().AddForce((_pos - GameObject.Find("player").GetComponent<Transform>().position).normalized * GameObject.Find("player").GetComponent<shoot>().speed);
        Debug.Log("aaa");
        SceneManager.MoveGameObjectToScene(ghost.gameObject, m_simulationScene);

        m_line.positionCount = m_iMaxPhysicsFrame;

        for (int i = 0; i < m_iMaxPhysicsFrame; i++)
        {
            m_physicsScene.Simulate(Time.fixedDeltaTime);
            m_line.SetPosition(i, ghost.transform.position);
        }
        Destroy(ghost.gameObject);
    }
}