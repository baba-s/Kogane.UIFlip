using UnityEngine;
using UnityEngine.UI;

namespace UniUIFlip
{
	/// <summary>
	/// uGUI のオブジェクトを上下左右反転できるコンポーネント
	/// </summary>
	[DisallowMultipleComponent]
	public sealed class UIFlip : BaseMeshEffect
	{
		//================================================================================
		// 変数(SerializeField)
		//================================================================================
		[SerializeField] private bool m_isHorizontal = false;	// 左右反転する場合 true
		[SerializeField] private bool m_isVertical   = false;	// 上下反転する場合 true
		
		//================================================================================
		// 関数
		//================================================================================
		/// <summary>
		/// メッシュを更新する時に呼び出されます
		/// </summary>
		public override void ModifyMesh( VertexHelper vh )
		{
			var vertex = new UIVertex();

			for ( int i = 0; i < vh.currentVertCount; i++ )
			{
				vh.PopulateUIVertex( ref vertex, i );

				var pos = vertex.position;
				var x   = m_isHorizontal ? -pos.x : pos.x;
				var y   = m_isVertical ? -pos.y : pos.y;

				vertex.position = new Vector3( x, y, 0 );
				vh.SetUIVertex( vertex, i );
			}
		}
	}
}