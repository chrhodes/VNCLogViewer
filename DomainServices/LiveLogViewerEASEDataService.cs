using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using VNC;
using VNC.Core.DomainServices;

using VNCLogViewer.Domain;
using VNCLogViewer.Persistence.Data;

namespace VNCLogViewer.DomainServices
{
    // NOTE(crhodes)
    // This creates a new context each time.  How would HasChanges work?

    public class LiveLogViewerEASEDataService : ILiveLogViewerEASEDataService
    {
        private Func<VNCLogViewerDbContext> _contextCreator;

        private ConnectedRepository<LiveLogViewerEASE> _repository;

        #region Constructors

        public LiveLogViewerEASEDataService(Func<VNCLogViewerDbContext> context)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            _contextCreator = context;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion Constructors

        #region Public Methods

        #region All

        public IEnumerable<LiveLogViewerEASE> All()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerEASE>(context);
                return _repository.All();
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task<List<LiveLogViewerEASE>> AllAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerEASE>(context);
                return await _repository.AllAsync();
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<LiveLogViewerEASE> AllInclude(
            params Expression<Func<LiveLogViewerEASE, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerEASE>(context);
                return _repository.AllInclude(includeProperties);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<LiveLogViewerEASE>> AllIncludeAsync(
            params Expression<Func<LiveLogViewerEASE, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerEASE>(context);
                return await _repository.AllIncludeAsync(includeProperties);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion All

        #region Find

        public LiveLogViewerEASE FindById(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerEASE>(context);
                return _repository.FindById(entityId);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task<LiveLogViewerEASE> FindByIdAsync(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerEASE>(context);
                return await _repository.FindByIdAsync(entityId);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<LiveLogViewerEASE> FindBy(
            Expression<Func<LiveLogViewerEASE, bool>> predicate)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerEASE>(context);
                return _repository.FindBy(predicate);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<LiveLogViewerEASE>> FindByAsync(
            Expression<Func<LiveLogViewerEASE, bool>> predicate)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerEASE>(context);
                return await _repository.FindByAsync(predicate);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<LiveLogViewerEASE> FindByInclude(
            Expression<Func<LiveLogViewerEASE, bool>> predicate,
            params Expression<Func<LiveLogViewerEASE, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerEASE>(context);
                return _repository.FindByInclude(predicate, includeProperties);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<LiveLogViewerEASE>> FindByIncludeAsync(
            Expression<Func<LiveLogViewerEASE, bool>> predicate,
            params Expression<Func<LiveLogViewerEASE, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerEASE>(context);
                return await _repository.FindByIncludeAsync(predicate, includeProperties);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        // TODO(crhodes)
        // Decide if we need FindByKey

        #endregion Find

        #region Insert

        public void Insert(LiveLogViewerEASE entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerEASE>(context);
                _repository.Insert(entity);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task InsertAsync(LiveLogViewerEASE entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerEASE>(context);
                await _repository.InsertAsync(entity);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion Insert

        #region Update

        public void Update(LiveLogViewerEASE entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerEASE>(context);
                _repository.Update(entity);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task UpdateAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerEASE>(context);
                await _repository.UpdateAsync();
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task UpdateAsync(LiveLogViewerEASE entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerEASE>(context);

                if (entity.Id <= 0)
                {
                    await _repository.InsertAsync(entity);
                }
                else
                {
                    await _repository.UpdateAsync(entity);
                }
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion Update

        #region Delete

        public void Delete(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerEASE>(context);
                _repository.Delete(entityId);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task DeleteAsync(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerEASE>(context);
                await _repository.DeleteAsync(entityId);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public bool HasChanges()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            // TODO(crhodes)
            // Hum.  How to determine if something has changed that can drive the UI logic.
            // This wont' work as we are creating a brand new context.

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerEASE>(context);
                var result = _repository.HasChanges();
                return result;
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);

        }

        #endregion Delete

        #endregion

    }
}
