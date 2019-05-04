#pragma once

#include <string>
#include <functional>

#include <bakkesmod/wrappers/gamewrapper.h>

class EventWrapper
{
public:
	virtual ~EventWrapper() = default;

public:
	virtual void HookEvent(const std::string& eventName, const std::function<void(std::string)>& callback) const = 0;
	virtual void UnhookEvent(const std::string& eventName) const = 0;
};