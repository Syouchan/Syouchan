//�쐬���@2021/09/20 �쐬�ҁF�c��
//�A�C�e��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "CreateItemDataBase")]
public class ItemDataBase : ScriptableObject
{

	[SerializeField]
	private List<Item> itemLists = new List<Item>();

	//�@�A�C�e�����X�g��Ԃ�
	public List<Item> GetItemLists()
	{
		return itemLists;
	}
}