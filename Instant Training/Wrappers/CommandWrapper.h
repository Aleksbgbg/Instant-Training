#pragma once

#include <string>

class CommandWrapper
{
public:
	virtual ~CommandWrapper() = default;

public:
	virtual void ExecuteCommand(const std::string& command) const = 0;
};