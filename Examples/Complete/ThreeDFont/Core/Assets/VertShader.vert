#version 300 es

in vec3 fuVertex;
in vec3 fuNormal;
uniform mat4 xform;

out vec3 normal;

void main()
{
	normal = fuNormal;
    gl_Position = xform * vec4(fuVertex, 1.0);
}