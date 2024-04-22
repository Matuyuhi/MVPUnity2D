using UnityEngine;

namespace Core.Utilities
{
    public static class RaycastEx
    {
        /// <summary>
        /// 指定オブジェクトの下方向に指定距離内に他のオブジェクトが存在するかどうかを判定します。
        /// </summary>
        /// <param name="targetObj">判定対象のオブジェクト</param>
        /// <param name="distance">判定距離</param>
        /// <param name="layerMask">判定対象となるレイヤーのマスク</param>
        /// <returns>下方向に指定距離内に他のオブジェクトが存在するかどうか</returns>
        public static bool IsGroundBelow(this GameObject targetObj, float distance) {
            // Raycastを飛ばす方向
            var direction = Vector3.down;

            // Raycastの開始位置
            var startPosition = targetObj.transform.position;

            // Raycastを実行
            var isHit = Physics.Raycast(startPosition, direction, out var hit, distance);

            // Raycastが当たった場合は、地面が存在すると判定
            if (isHit) {
                return true;
            }

            // Raycastが当たらない場合は、地面が存在しないと判定
            return false;
        }
    }
}