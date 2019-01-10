// Amplify Shader Editor - Visual Shader Editing Tool
// Copyright (c) Amplify Creations, Lda <info@amplify.pt>
#if UNITY_EDITOR_WIN
using System;

namespace AmplifyShaderEditor
{
	[Serializable]
	[NodeAttributes( "Primitive ID", "Vertex Data", "Per-primitive identifier automatically generated by the runtime" )]
	public class PrimitiveIDVariableNode : ParentNode
	{
		protected override void CommonInit( int uniqueId )
		{
			base.CommonInit( uniqueId );
			AddOutputPort( WirePortDataType.INT, "Out" );
			m_previewShaderGUID = "92c1b588d7658594cb219696f593f64b";
		}

		public override string GenerateShaderForOutput( int outputId, ref MasterNodeDataCollector dataCollector, bool ignoreLocalvar )
		{
			if( !dataCollector.IsTemplate )
			{
				UIUtils.ShowMessage( m_nodeAttribs.Name + " is not supported on surface shaders." );
				return "0";
			}

			if ( dataCollector.PortCategory == MasterNodePortCategory.Vertex )
			{
				UIUtils.ShowMessage( m_nodeAttribs.Name + " is not supported on Vertex ports" );
				return "0";
			}
			
			return dataCollector.TemplateDataCollectorInstance.GetPrimitiveId();
		}
	}
}
#endif