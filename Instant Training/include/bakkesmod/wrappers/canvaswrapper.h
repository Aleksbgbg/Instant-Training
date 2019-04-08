#pragma once
#include "WrapperStructs.h"
#include "./Engine/ActorWrapper.h"


class BAKKESMOD_PLUGIN_IMPORT CanvasWrapper
{
public:
	CONSTRUCTORS(CanvasWrapper)

	void SetPosition(Vector2 pos);
	Vector2 GetPosition();
	void SetColor(char Red, char Green, char Blue, char Alpha);//0-255
	void DrawBox(Vector2 size);
	void FillBox(Vector2 size);
	void FillTriangle(Vector2 p1, Vector2 p2, Vector2 p3, LinearColor color);
	void DrawString(string text);
	void DrawString(string text, int xScale, int yScale);
	void DrawLine(Vector2 start, Vector2 end);
	void DrawLine(Vector2 start, Vector2 end, float width);
	void DrawRect(Vector2 start, Vector2 end);
	Vector2 Project(Vector location);
	Vector2 GetSize();
private:
	PIMPL
};
