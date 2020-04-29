using System;
using System.Collections.Generic;

namespace delegates_and_events
{
	class DBEdu
	{
		List<Project> seznam { get; set; } = new List<Project>();

		public void AddProject(Project project)
		{
			seznam.Add(project);
			OnAdd?.Invoke(this, EventArgs.Empty);
		}

		public event EventHandler OnAdd;
	}
}
