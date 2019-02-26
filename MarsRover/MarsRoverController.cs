using MarsRover.Engine.Command;
using MarsRover.Engine.Plateau;
using MarsRover.Engine.Rover;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace MarsRover
{
    public class MarsRoverController : IMarsRoverController
    {
        ICommandParser _commandParser;
        IPlateau _plateau;
        List<IRover> _deployedRoverList;
        IRover _currentRover;

        public MarsRoverController(ICommandParser commandParser)
        {
            _commandParser = commandParser;
            _deployedRoverList = new List<IRover>();
        }

        public string ExecuteCommand(string command)
        {
            try
            {
                var commandList = _commandParser.ParseCommand(command);
                foreach (var commandItem in commandList)
                {
                    switch (commandItem.Key)
                    {
                        case CommandType.SetPlateau:
                            ISetPlateauCommand setPlateauCommand = ContainerConfig.Container.Resolve<ISetPlateauCommand>();
                            setPlateauCommand.Initialize(commandItem.Value);
                            setPlateauCommand.Execute();
                            _plateau = setPlateauCommand.GetPlateau();
                            break;
                        case CommandType.DeployRover:
                            IDeployRoverCommand deployRoverCommand = ContainerConfig.Container.Resolve<IDeployRoverCommand>();
                            deployRoverCommand.Initialize(_plateau, _deployedRoverList, commandItem.Value);
                            deployRoverCommand.Execute();
                            _currentRover = deployRoverCommand.GetRover();
                            break;
                        case CommandType.MoveRover:
                            IMoveRoverCommand moveRoverCommand = ContainerConfig.Container.Resolve<IMoveRoverCommand>();
                            moveRoverCommand.Initialize(_plateau, _deployedRoverList, _currentRover, commandItem.Value);
                            moveRoverCommand.Execute();
                            break;
                    }
                }

                StringBuilder result = new StringBuilder();
                foreach (var rover in _deployedRoverList)
                {
                    result.AppendLine(String.Format("{0} {1} {2}", rover.Position.X, rover.Position.Y, rover.Position.Direction.ToString()[0]));
                }
                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
    }
}
