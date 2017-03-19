using MailUI.Model;

namespace MailUI.ViewModel.ManagmentViewModels
{
    public interface ITemplateView
    {
        void Attach(ManagmentViewModel managmentView, TemplateModel contentTemplate);

        string InstanceType { get; }

        TemplateModel Template { get; set; }

        string[] Content { get; set; }
    }
}