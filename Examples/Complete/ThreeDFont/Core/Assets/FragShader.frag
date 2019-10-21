#version 300 es

#ifdef GL_ES
precision highp float;
#endif

in vec3 normal;
out vec4 oColor;

void main()
{
	oColor = vec4(normal*0.5+0.5, 1.0);
}