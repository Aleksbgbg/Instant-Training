#pragma once
#include "../plugin/bakkesmodplugin.h"
#include "./Engine/ObjectWrapper.h"
#include "wrapperstructs.h"
#include <vector>
class PluginManagerWrapper : public ObjectWrapper
{
public:
	CONSTRUCTORS(PluginManagerWrapper);
	std::vector<BakkesMod::Plugin::PluginInfo> GetLoadedPlugins();

private:
	PIMPL
};

