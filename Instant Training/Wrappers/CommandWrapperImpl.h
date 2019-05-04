#pragma once

#include <memory>

#include "CommandWrapper.h"

#include <bakkesmod/wrappers/gamewrapper.h>

class CommandWrapperImpl : CommandWrapper
{
public:
	explicit CommandWrapperImpl(const std::shared_ptr<GameWrapper> gameWrapper);

public:
	void ExecuteCommand(const std::string& command) const override;

private:
	const std::shared_ptr<GameWrapper> gameWrapper;
};