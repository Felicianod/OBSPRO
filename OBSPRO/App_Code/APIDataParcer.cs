using Newtonsoft.Json.Linq;
using OBSPRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBSPRO.App_Code
{   
    public class APIDataParcer
    {
        DataRetrieval api = new DataRetrieval();
        User usr = new User();
        public Dashboard getDashboard(string emp_id)
        {
            Dashboard dashboard = new Dashboard();
            string raw_data = api.getOpenReadyObservations(emp_id);
            JObject parsed_result = JObject.Parse(raw_data);
            
            foreach (var res in parsed_result["resource"])
            {
                Observation obs = new Observation();
                obs.form_inst_id = (string)res["ObsColFormInstID"];
                obs.observed_id = (string)res["dsc_observed_emp_id"];
                obs.observer_id = (string)res["dsc_observer_emp_id"];
                obs.status = (string)res["obs_inst_status"];
                obs.observed_first_name = (string)res["dsc_observed_first_name"];
                obs.observed_last_name = (string)res["dsc_observed_last_name"];
                obs.observed_adp_id = (string)res["ObservedADPID"];
                obs.form_title = (string)res["ColFormTitle"];
                obs.obs_start_time = Convert.ToDateTime((string)res["ColFormStartDateTime"]);
                switch (obs.status)
                {
                    case "OPEN":
                        dashboard.user_open_obs.Add(obs);
                        break;
                    case "READY TO VERIFY":
                        dashboard.user_ready_obs.Add(obs);
                        break;
                    case "COMPLETE":
                        dashboard.user_complete_obs.Add(obs);
                        break;
                }
            }
            return dashboard;
        }
        public OBSCollectionForm getFormInstance(int formId)
        {
            OBSCollectionForm obsColForm = new OBSCollectionForm();
            JObject parsed_result = JObject.Parse(api.getObsCollForm(formId));
            Section current_section = new Section();
            current_section.sectionName = String.Empty;
            obsColForm.observedEmployeeId = (string)parsed_result["observationsColFormData"]["ObservedEmployeeID"];
            obsColForm.observerEmployeeId = (string)parsed_result["observationsColFormData"]["ObserverEmployeeID"];
            try { obsColForm.hiredDate = Convert.ToDateTime((string)parsed_result["observationsColFormData"]["hiredDate"]); }
            catch { }
            obsColForm.lc_id = (string)parsed_result["observationsColFormData"]["DSC_LC_ID"];
            obsColForm.customer_id = (string)parsed_result["observationsColFormData"]["customer"];
            obsColForm.obsColFormId = (int)parsed_result["observationsColFormData"]["OBSColFormID"];
            obsColForm.colFormTitle = (string)parsed_result["observationsColFormData"]["ColFormTitle"];
            obsColForm.colFormSubtitle = (string)parsed_result["observationsColFormData"]["ColFormSubTitle"];
            obsColForm.colFormVersion = (string)parsed_result["observationsColFormData"]["ColFormVersion"];
            obsColForm.obsInstId = (string)parsed_result["observationsColFormData"]["OBSInstID"];
            obsColForm.obsColFormInstId = (string)parsed_result["observationsColFormData"]["OBSColFormInstID"];
            obsColForm.colFormStartDateTime = Convert.ToDateTime((string)parsed_result["observationsColFormData"]["ColFormStartDateTime"]);
            obsColForm.dBColFormStatus = (string)parsed_result["observationsColFormData"]["DBColFormStatus"];
            obsColForm.colFormStatus = (string)parsed_result["observationsColFormData"]["ColFormStatus"];
            JArray questions = (JArray)parsed_result["observationsColFormData"]["questions"];
            foreach (var quest in questions)
            {
                if (current_section.sectionName != (string)quest["SectionName"])
                {

                    Section newSection = new Section();
                    newSection.sectionName = (string)quest["SectionName"];
                    if (!String.IsNullOrEmpty(current_section.sectionName))
                    {
                        obsColForm.sections.Add(current_section);
                    }
                    current_section = newSection;
                }
                Question formQuestion = new Question();
                formQuestion.uniqueQuestionId = (int)quest["UniqueQuestionId"];
                formQuestion.questionId = (int)quest["QuestionId"];
                formQuestion.questionOrder = (int)quest["QuestionOrder"];
                formQuestion.questionText = (string)quest["QuestionText"];
                formQuestion.answerType = (string)quest["AnswerType"];
                formQuestion.showsNA = (string)quest["showsNA"];
                formQuestion.canAddComment = (string)quest["canAddComment"];
                formQuestion.mustAddComment = (string)quest["MustAddComment"];
                formQuestion.answerChanged = (string)quest["answerChanged"];
                formQuestion.obscolformquestwgt = (int)quest["obscolformquestwgt"];
                formQuestion.comments = (string)quest["comments"];
                JArray answers = (JArray)quest["answers"];
                if (answers.HasValues)
                {
                    foreach (var ans in answers)
                    {
                        Answer answer = new Answer();
                        answer.answerId = ans["answerId"] == null ? 0 : (int)ans["answerId"];
                        answer.cfiqid = ans["CFIQID"] == null ? 0 : (int)ans["CFIQID"];
                        answer.obscolanswgt = (int)ans["obscolanswgt"];
                        answer.answerOrder = (int)ans["answerOrder"];
                        answer.answerText = (string)ans["answerText"];
                        formQuestion.answers.Add(answer);
                    }
                }
                JArray answer_values = (JArray)quest["answervalues"];
                if (answer_values != null && answer_values.HasValues)
                {
                    foreach (var ans_val in answer_values)
                    {
                        Answer answer_value = new Answer();
                        answer_value.answerId = 0;
                        answer_value.cfiqid = 0;
                        answer_value.obscolanswgt = (int)ans_val["obscolanswgt"];
                        answer_value.answerOrder = (int)ans_val["answerOrder"];
                        answer_value.answerText = (string)ans_val["answerText"];
                        formQuestion.naSelected = answer_value.answerText.Equals("n/a") ? true : false;
                        if (!formQuestion.naSelected)
                        {
                            var selected_answer = formQuestion.answers.FirstOrDefault(x => x.answerText == answer_value.answerText);
                            if (selected_answer != null)
                            {
                                selected_answer.isSelected = true;
                            }
                        }
                        formQuestion.answerValues.Add(answer_value);

                    }
                }

                current_section.questions.Add(formQuestion);
            }
            obsColForm.sections.Add(current_section);
            return obsColForm;
        }
        public List<Observation> getAllObservations(string emp_id, string frmStatus)
        {
            List<Observation> all_obs = new List<Observation>();
            usr.setUser();
            JObject parsed_result = JObject.Parse(api.getOpenReadyObservations(usr.emp_id));
            foreach (var res in parsed_result["resource"])
            {
                Observation obs = new Observation();
                obs.form_inst_id = (string)res["ObsColFormInstID"];
                obs.observed_id = (string)res["dsc_observed_emp_id"];
                obs.observer_id = (string)res["dsc_observer_emp_id"];
                obs.status = (string)res["obs_inst_status"];
                obs.observed_first_name = (string)res["dsc_observed_first_name"];
                obs.observed_last_name = (string)res["dsc_observed_last_name"];
                obs.observed_adp_id = (string)res["ObservedADPID"];
                obs.form_title = (string)res["ColFormTitle"];
                obs.obs_start_time = Convert.ToDateTime((string)res["ColFormStartDateTime"]);
                if (String.IsNullOrEmpty(frmStatus) || frmStatus.Equals(obs.status)) { all_obs.Add(obs); }
            }
            return all_obs;
        }


    }
}