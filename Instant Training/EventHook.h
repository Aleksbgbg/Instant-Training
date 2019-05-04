#pragma once

#include <functional>

class EventHook
{
public:
	virtual ~EventHook() = default;

public:
	virtual void Hook(const std::function<void()>& function) const = 0;
	virtual void Unhook() const = 0;
};