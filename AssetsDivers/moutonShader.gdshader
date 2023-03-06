shader_type canvas_item;

uniform float speed = 2.0;
uniform float dis = 1.0;

void vertex(){
 VERTEX.y += sin(TIME * speed) * dis * (UV.y-1.0);
 VERTEX.x += sin(TIME * speed) * dis * (UV.y-1.0);
}