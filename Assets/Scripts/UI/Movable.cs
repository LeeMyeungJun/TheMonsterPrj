using UnityEngine;
using UnityEngine.EventSystems;

/// <summary> ��� �巡�� �� ��ӿ� ���� UI �̵� </summary>
public class Movable : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public Transform _targetTr; // �̵��� UI

    private Vector2 _startingPoint;
    private Vector2 _moveBegin;
    private Vector2 _moveOffset;

    private void Awake()
    {
        // �̵� ��� UI�� �������� ���� ���, �ڵ����� this�� �ʱ�ȭ
        if (_targetTr == null)
            _targetTr = this.transform;
    }

    // �巡�� ���� ��ġ ����
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        _startingPoint = _targetTr.position;
        _moveBegin = eventData.position;
    }

    // �巡�� : ���콺 Ŀ�� ��ġ�� �̵�
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        _moveOffset = eventData.position - _moveBegin;
        _targetTr.position = _startingPoint + _moveOffset;
    }
}