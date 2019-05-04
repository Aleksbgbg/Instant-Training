#include "InstantTraining.h"

BAKKESMOD_PLUGIN(InstantTraining, "InstantTraining", "1.0", PLUGINTYPE_FREEPLAY)

void InstantTraining::onLoad()
{
	modBootstrapper = std::make_unique<ModBootstrapper>(gameWrapper);
}

void InstantTraining::onUnload()
{
}